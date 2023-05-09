using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace sisedit
{
    [TypeConverter(typeof(PropertySorter))]
    internal class SummaryInfoProperties
    {
        [Description("PID_LASTPRINTED = date and time of installation image")]
        [PropertyOrder(100)]
        public DateTime Printed { get; set; }

        [Description("PID_CREATE_DTM = a timestamp when the transform was created")]
        [PropertyOrder(110)]
        public DateTime Created { get; set; }

        [Description("PID_LASTSAVE_DTM = date and time of last package modification")]
        [PropertyOrder(120)]
        public DateTime Saved { get; set; }

        [DefaultValue(1252)]
        [Description("PID_CODEPAGE = a code page for the summary information stream")]
        [PropertyOrder(10)]
        public int Codepage { get; set; }

        [DefaultValue(200)]
        [Description("PID_PAGECOUNT = minimum Windows Installer version: Major * 100 + Minor")]
        [PropertyOrder(130)]
        public int Schema { get; set; }

        [DefaultValue(8)]
        [DisplayName("Source flags")]
        [Description("PID_WORDCOUNT = source flags: 1 = short names, 2 = compressed, 4 = administrative image, 8 = no elevated privileges required")]
        [Editor(typeof(FlagsDropDownEditor), typeof(UITypeEditor))]
        [PropertyOrder(140)]
        public int SourceFlags { get; set; }

        [DefaultValue(0)]
        [Description("PID_SECURITY = 0 = read/write, 2 = read-only recommended, 4 = read-only enforced. "
                     + "\nThis property should be set to read-only recommended (2) for an installation data"
                     + "base and to read-only enforced (4) for a transform or patch.")]
        [PropertyOrder(170)]
        public int Security { get; set; }

        [DefaultValue("Installation Database")]
        [Description("PID_TITLE = typically just \"Transform\" or \"Installation database\"")]
        [PropertyOrder(20)]
        [TypeConverter(typeof(PostTypeConverter))]
        public string Title { get; set; }

        [Description("PID_SUBJECT = an original subject of the target")]
        [PropertyOrder(30)]
        public string Subject { get; set; }

        [Description("PID_AUTHOR = an original manufacturer of the target")]
        [PropertyOrder(40)]
        public string Author { get; set; }

        [DefaultValue("Installer,MSI,Database")]
        [Description("PID_KEYWORDS = keywords for the transform, typically include at least \"Installer\"")]
        [PropertyOrder(50)]
        public string Keywords { get; set; }

        [DefaultValue("This installer database contains the logic and data required to install <INSERT_NAME_HERE>")]
        [Description("PID_COMMENTS = describes what this package does")]
        [PropertyOrder(60)]
        public string Comments { get; set; }

        [DefaultValue("Intel;1033")]
        [DisplayName("Platform and language")]
        [Description("PID_TEMPLATE = target platform(s);language(s)")]
        [PropertyOrder(70)]
        public string PlatformAndLanguage { get; set; }

        [DisplayName("Updated platform and language")]
        [Description("PID_LASTAUTHOR = used for transforms only: new_target_platform(s);language(s)")]
        [PropertyOrder(80)]
        public string UpdatedPlatformAndLanguage { get; set; }

        [DisplayName("Product codes")]
        [Description("PID_REVNUMBER = package code for installation. For transform {productcode}version;{newproductcode}newversion;upgradecode")]
        [PropertyOrder(90)]
        public string ProductCodes { get; set; }

        [DefaultValue("Windows Installer")]
        [DisplayName("Creating application")]
        [Description("PID_APPNAME = an application which created the transform, \"Windows Installer\" for MSI")]
        [PropertyOrder(160)]
        public string CreatingApplication { get; set; }

        [DefaultValue(typeof(TransformValidationFlags), "0x3f")]
        [DisplayName("Validation flags")]
        [Description("PID_CHARCOUNT = relevent for transforms only. The upper word contains the transform validation flags. "
                     + "The lower word contains the transform error condition flags."
                     + "This property should be Null in an installation package or patch package")]
        [PropertyOrder(150)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TransformValidationFlags ValidationFlags { get; set; }

        //public bool ShouldSerializem_ValidationFlags()
        //{
        //    return m_ValidationFlags.Flags == 0x3f;// && m_ValidationFlags.FValidation==0;
        //}

        //public void Resetm_ValidationFlags()
        //{
        //    m_ValidationFlags.Flags = 0x3f;
        //    //m_ValidationFlags.FValidation=0;
        //}

    }
}
