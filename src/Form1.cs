using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInstaller;

namespace sisedit
{
    public partial class Form1 : Form
    {
        private bool _doBackup = true;
        private Installer _installer;
        private string _fileName;
        private readonly SummaryInfoProperties _sisProperties = new SummaryInfoProperties();

        public Form1(string[] args)
        {
            InitializeComponent();
            _fileName = (args.Length > 0) ? args[0] : "";
        }

        private static void ApplyDefaultValues(SummaryInfoProperties self)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(self)) {
                if (prop.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute attr)
                    prop.SetValue(self, attr.Value);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog()) {
                //Set the root folder
                //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.Filter = "MST and MSI files (*.mst, *.msi)|*.mst;*.msi|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.SupportMultiDottedExtensions = true;
                //dlg.RestoreDirectory = false;

                if (dlg.ShowDialog() == DialogResult.OK) {
                    _fileName = dlg.FileName;
                    LoadSis();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName)) {
                btnSaveAs_Click(sender, e);
                return;
            }
            SummaryInfo sis = null;

            try {
                if (_doBackup) {
                    File.Copy(_fileName, $"{_fileName}.bak", true);
                } else {
                    _doBackup = true;
                }

                if ((File.GetAttributes(_fileName) & FileAttributes.ReadOnly) != 0) {
                    if (MessageBox.Show($"File {_fileName} is read-only. Overwrite?", "Read-only file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        File.SetAttributes(_fileName, File.GetAttributes(_fileName) & ~FileAttributes.ReadOnly);
                    else
                        return;
                }

                sis = _installer.get_SummaryInformation(_fileName, 20);
                if (sis != null) {
                    try {
                        sis.SetSisProperty(SisProp.CodePage, _sisProperties.Codepage);
                        sis.SetSisProperty(SisProp.Title, _sisProperties.Title ?? string.Empty);
                        sis.SetSisProperty(SisProp.Subject, _sisProperties.Subject ?? string.Empty);
                        sis.SetSisProperty(SisProp.Author, _sisProperties.Author ?? string.Empty);
                        sis.SetSisProperty(SisProp.Keywords, _sisProperties.Keywords ?? string.Empty);
                        sis.SetSisProperty(SisProp.Comments, _sisProperties.Comments ?? string.Empty);
                        sis.SetSisProperty(SisProp.PlatformAndLanguage, _sisProperties.PlatformAndLanguage ?? string.Empty);
                        sis.SetSisProperty(SisProp.UpdatedPlatformAndLanguage, _sisProperties.UpdatedPlatformAndLanguage ?? string.Empty);
                        sis.SetSisProperty(SisProp.ProductCodes, _sisProperties.ProductCodes ?? string.Empty);
                        if (_sisProperties.Saved != DateTime.MinValue)
                            sis.SetSisProperty(SisProp.Saved, _sisProperties.Saved);
                        if (_sisProperties.Printed != DateTime.MinValue)
                            sis.SetSisProperty(SisProp.Printed, _sisProperties.Printed);
                        if (_sisProperties.Created != DateTime.MinValue)
                            sis.SetSisProperty(SisProp.Created, _sisProperties.Created);
                        sis.SetSisProperty(SisProp.SourceFlags, _sisProperties.SourceFlags);
                        sis.SetSisProperty(SisProp.Schema, _sisProperties.Schema);
                        sis.SetSisProperty(SisProp.ValidationFlags, (int)_sisProperties.ValidationFlags.Flags);
                        sis.SetSisProperty(SisProp.CreatingApplication, _sisProperties.CreatingApplication ?? string.Empty);
                        sis.SetSisProperty(SisProp.Security, _sisProperties.Security);
                    } catch (Exception ee) {
                        MessageBox.Show($"Exception:\n\n{ee}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } finally {
                        sis.Persist();
                    }
                    //int j = 0;
                    //foreach (int i in Enum.GetValues(typeof(_SISProp))) {
                    //    string s = Convert.ToString(sis.get_Property(i));
                    //    if (s == null) s = "";
                    //    m_sis[i] = s;
                    //    lstSIS.Items[j++].SubItems[1].Text = s;
                    //}
                }
            } catch (Exception ee) {
                MessageBox.Show($"Exception:\n\n{ee}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                if (sis != null) {
                    Marshal.FinalReleaseComObject(sis);
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog()) {
                dlg.Filter = "MST and MSI files (*.mst, *.msi)|*.mst;*.msi|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.DefaultExt = "msi";
                dlg.SupportMultiDottedExtensions = true;

                if (dlg.ShowDialog() == DialogResult.OK) {
                    var fname = dlg.FileName;
                    Database d = null;
                    try {
                        if (!File.Exists(fname)) {
                            if (!string.Equals(Path.GetExtension(fname), ".msi", StringComparison.OrdinalIgnoreCase)) {
                                if (MessageBox.Show("Only 'msi' files can be used as a new SummaryInformation container. Do you wish to save as 'msi'?",
                                                    "No 'mst' files allowed for new file",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question) == DialogResult.Yes)
                                    fname += ".msi";
                                else
                                    return;
                            }

                            d = _installer.OpenDatabase(fname, MsiOpenDatabaseMode.msiOpenDatabaseModeCreateDirect);
                            d.Commit();
                            _doBackup = false;
                        }
                    } catch (Exception ee) {
                        MessageBox.Show($"Exception:\n\n{ee}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } finally {
                        if (d != null) {
                            Marshal.FinalReleaseComObject(d);
                            d = null;
                        }
                    }
                    _fileName = fname;
                    Text = $"{_fileName} - SummaryInformationStream Editor";
                    btnSave_Click(sender, e);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var item = propGrid.SelectedGridItem;
            restoreDefaultsToolStripMenuItem.Enabled = item.PropertyDescriptor.CanResetValue(item.Parent.Value);
            generateGUIDToolStripMenuItem.Visible = item.PropertyDescriptor.DisplayName == "Product codes";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var t = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            _installer = (Installer)Activator.CreateInstance(t);

            PG_ComboBoxes.AddCombobox("Title", new List<string> { "Transform", "Installation Database" }, true);
            PG_ComboBoxes.AddCombobox("Product version", new List<string> {
                                "No check",
                                "Check major version only",
                                "Check major and minor versions only",
                                "Check major, minor, and update versions"
                           },
                           false);

            propGrid.SelectedObject = _sisProperties;
            ApplyDefaultValues(_sisProperties);

            if (_fileName != "") LoadSis();
        }

        private void generateGUIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sisProperties.ProductCodes = $"{{{Guid.NewGuid().ToString().ToUpper()}}}";
            propGrid.Refresh();
        }

        private void LoadSis()
        {
            SummaryInfo sis = null;
            try {
                sis = _installer.get_SummaryInformation(_fileName, 0);
                if (sis != null) {
                    _sisProperties.Codepage = Convert.ToInt32(sis.GetSisProperty(SisProp.CodePage));
                    _sisProperties.Title = Convert.ToString(sis.GetSisProperty(SisProp.Title));
                    _sisProperties.Subject = Convert.ToString(sis.GetSisProperty(SisProp.Subject));
                    _sisProperties.Author = Convert.ToString(sis.GetSisProperty(SisProp.Author));
                    _sisProperties.Keywords = Convert.ToString(sis.GetSisProperty(SisProp.Keywords));
                    _sisProperties.Comments = Convert.ToString(sis.GetSisProperty(SisProp.Comments));
                    _sisProperties.PlatformAndLanguage = Convert.ToString(sis.GetSisProperty(SisProp.PlatformAndLanguage));
                    _sisProperties.UpdatedPlatformAndLanguage = Convert.ToString(sis.GetSisProperty(SisProp.UpdatedPlatformAndLanguage));
                    _sisProperties.ProductCodes = Convert.ToString(sis.GetSisProperty(SisProp.ProductCodes));
                    _sisProperties.Saved = Convert.ToDateTime(sis.GetSisProperty(SisProp.Saved));
                    _sisProperties.Printed = Convert.ToDateTime(sis.GetSisProperty(SisProp.Printed));
                    _sisProperties.Created = Convert.ToDateTime(sis.GetSisProperty(SisProp.Created));
                    _sisProperties.SourceFlags = Convert.ToInt32(sis.GetSisProperty(SisProp.SourceFlags));
                    _sisProperties.Schema = Convert.ToInt32(sis.GetSisProperty(SisProp.Schema));
                    _sisProperties.ValidationFlags = new TransformValidationFlags(sis.GetSisProperty(SisProp.ValidationFlags));
                    _sisProperties.CreatingApplication = Convert.ToString(sis.GetSisProperty(SisProp.CreatingApplication));
                    _sisProperties.Security = Convert.ToInt32(sis.GetSisProperty(SisProp.Security));
                    //int j = 0;
                    //foreach (int i in Enum.GetValues(typeof(_SISProp))) {
                    //    string s = Convert.ToString(sis.get_Property(i));
                    //    if (s == null) s = "";
                    //    m_sis[i] = s;
                    //    lstSIS.Items[j++].SubItems[1].Text = s;
                    //}
                    btnSave.Enabled = true;
                    Text = $"{_fileName} - SummaryInformationStream Editor";
                    propGrid.Refresh();
                }
            } catch (Exception ee) {
                MessageBox.Show($"Exception:\n\n{ee}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                if (sis != null) Marshal.FinalReleaseComObject(sis);
            }
        }

        private void restoreDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GridItem item = propGrid.SelectedGridItem;
            //item.PropertyDescriptor.ResetValue(propGrid.SelectedObject);
            propGrid.ResetSelectedProperty();
            propGrid.Refresh();
        }
        //          private void propGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        //          {
        //             //Trace.WriteLine("Changed "+e.ChangedItem);
        //             propGrid.Refresh();
        //          }
    }
}
