using System;
using System.ComponentModel;
using System.Globalization;
using EnumsNET;

namespace sisedit
{
    internal enum ValidateVersion// : uint
    {
        [Description("No check")]
        None,
        [Description("Check major version only")]
        Major,
        [Description("Check major and minor versions only")]
        Minor,
        [Description("Check major, minor, and update versions")]
        Update
    }

    internal enum ValidateVersionComparison// : uint
    {
        [Description("No check")]
        None,
        [Description("Transform version < base version")]
        TransformLsBase,
        [Description("Transform version <= base version")]
        TransformLeBase,
        [Description("Transform version == base version")]
        TransformEqBase,
        [Description("Transform version >= base version")]
        TransformGeBase,
        [Description("Transform version > base version")]
        TransformGrBase
    }

    [TypeConverter(typeof(CustomConverter))]
    internal class TransformValidationFlags
    {
        private MsiTransformError _errorFlags;
        private MsiTransformValidation _validationFlags;

        public TransformValidationFlags()
        {
            _errorFlags = 0;
            _validationFlags = 0;
        }

        public TransformValidationFlags(uint flags) => Flags = flags;

        public TransformValidationFlags(object o) : this(Convert.ToUInt32(o)) { }

        public TransformValidationFlags(string s)
            : this(s.IndexOf("0x", StringComparison.OrdinalIgnoreCase) >= 0 ? Convert.ToUInt32(s, 16) : Convert.ToUInt32(s)) { }

        public override string ToString() => $"0x{Flags:X8}";

        [DisplayName("Deny different languages.")]
        [Description("Default language must match base database (MSITRANSFORM_VALIDATE_LANGUAGE).")]
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ValidateSameLanguage
        {
            get => _validationFlags.HasFlag(MsiTransformValidation.Language);
            set => SetValidationFlag(MsiTransformValidation.Language, value);
        }

        [DisplayName("Deny different products.")]
        [Description("Product must match base database (MSITRANSFORM_VALIDATE_PRODUCT).")]
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ValidateSameProduct
        {
            get => _validationFlags.HasFlag(MsiTransformValidation.Product);
            set => SetValidationFlag(MsiTransformValidation.Product, value);
        }

        [DisplayName("Deny different UpgradeCodes.")]
        [Description("UpgradeCode must match base database (MSITRANSFORM_VALIDATE_UPGRADECODE).")]
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ValidateSameUpgradeCode
        {
            get => _validationFlags.HasFlag(MsiTransformValidation.UpgradeCode);
            set => SetValidationFlag(MsiTransformValidation.UpgradeCode, value);
        }

        [DisplayName("Allow add an existing row.")] //0x00000001
        [Description("No error if adding a row that exists (MSITRANSFORM_ERROR_ADDEXISTINGROW).")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ErrorAddExistingRow
        {
            get => _errorFlags.HasFlag(MsiTransformError.AddExistingRow);
            set => SetErrorFlag(MsiTransformError.AddExistingRow, value);
        }

        [DisplayName("Allow delete a non existing row.")] //0x00000002
        [Description("No error if deleting a row that does not exist (MSITRANSFORM_ERROR_DELMISSINGROW).")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ErrorDeleteNonExistingRow
        {
            get => _errorFlags.HasFlag(MsiTransformError.DelMissingRow);
            set => SetErrorFlag(MsiTransformError.DelMissingRow, value);
        }

        [DisplayName("Allow add an existing table.")] //0x00000004
        [Description("No error if adding a table that exists (MSITRANSFORM_ERROR_ADDEXISTINGTABLE).")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ErrorAddExistingTable
        {
            get => _errorFlags.HasFlag(MsiTransformError.AddExistingTable);
            set => SetErrorFlag(MsiTransformError.AddExistingTable, value);
        }

        [DisplayName("Allow delete a non existing table.")] //0x00000008
        [Description("No error if deleting a table that does not exist (MSITRANSFORM_ERROR_DELMISSINGTABLE).")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ErrorDeleteNonExistingTable
        {
            get => _errorFlags.HasFlag(MsiTransformError.DelMissingTable);
            set => SetErrorFlag(MsiTransformError.DelMissingTable, value);
        }

        [DisplayName("Allow update a non existing row.")] //0x00000010
        [Description("No error if updating a row that does not exist (MSITRANSFORM_ERROR_UPDATEMISSINGROW).")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ErrorUpdateNonExistingRow
        {
            get => _errorFlags.HasFlag(MsiTransformError.UpdateMissingRow);
            set => SetErrorFlag(MsiTransformError.UpdateMissingRow, value);
        }

        [DisplayName("Allow change code page.")] //0x00000020
        [Description("No error if transform and database code pages do not match, and their code pages are neutral (MSITRANSFORM_ERROR_CHANGECODEPAGE)")]
        [DefaultValueAttribute(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ErrorChangeCodepage
        {
            get => _errorFlags.HasFlag(MsiTransformError.ChangeCodepage);
            set => SetErrorFlag(MsiTransformError.ChangeCodepage, value);
        }

        [Browsable(false)]
        public uint Flags
        {
            get => ((uint)_validationFlags << 16) | (uint)_errorFlags;
            set {
                _errorFlags = (MsiTransformError)value & MsiTransformError.All;
                _validationFlags = (MsiTransformValidation)(value >> 16) & MsiTransformValidation.All;
            }
        }

        [DisplayName("Product version")]
        [DefaultValue(ValidateVersion.None)]
        [Description("Which parts of version will be validated.")]
        [TypeConverter(typeof(EnumComboConverter))]
        public ValidateVersion ValidateProductVersion
        {
            get =>
                _validationFlags.HasFlag(MsiTransformValidation.MajorVersion)
                ? ValidateVersion.Major
                : _validationFlags.HasFlag(MsiTransformValidation.MinorVersion)
                ? ValidateVersion.Minor
                : _validationFlags.HasFlag(MsiTransformValidation.UpdateVersion)
                ? ValidateVersion.Update
                : ValidateVersion.None;
            set {
                _validationFlags = _validationFlags.RemoveFlags(MsiTransformValidation.AllVersionPartFlags);
                MsiTransformValidation f;
                switch (value) {
                    case ValidateVersion.Major:
                        f = MsiTransformValidation.MajorVersion;
                        break;
                    case ValidateVersion.Minor:
                        f = MsiTransformValidation.MinorVersion;
                        break;
                    case ValidateVersion.Update:
                        f = MsiTransformValidation.UpdateVersion;
                        break;
                    default:
                        f = MsiTransformValidation.None;
                        break;
                }
                _validationFlags = _validationFlags.CombineFlags(f);
            }
        }

        [DisplayName("Product version compare")]
        [DefaultValue(ValidateVersionComparison.None)]
        [Description("Comparison between a transform and a base package versions.")]
        [TypeConverter(typeof(EnumComboConverter))]
        public ValidateVersionComparison ValidateProductVersionComparison
        {
            get =>
                _validationFlags.HasFlag(MsiTransformValidation.NewLessBaseVersion)
                ? ValidateVersionComparison.TransformLsBase
                : _validationFlags.HasFlag(MsiTransformValidation.NewLessEqualBaseVersion)
                ? ValidateVersionComparison.TransformLeBase
                : _validationFlags.HasFlag(MsiTransformValidation.NewEqualBaseVersion)
                ? ValidateVersionComparison.TransformEqBase
                : _validationFlags.HasFlag(MsiTransformValidation.NewGreaterEqualBaseVersion)
                ? ValidateVersionComparison.TransformGeBase
                : _validationFlags.HasFlag(MsiTransformValidation.NewGreaterBaseVersion)
                ? ValidateVersionComparison.TransformGrBase
                : ValidateVersionComparison.None;
            set {
                _validationFlags = _validationFlags.RemoveFlags(MsiTransformValidation.AllVersionComparisonFlags);
                MsiTransformValidation f;
                switch (value) {
                    case ValidateVersionComparison.TransformLsBase:
                        f = MsiTransformValidation.NewLessBaseVersion;
                        break;
                    case ValidateVersionComparison.TransformLeBase:
                        f = MsiTransformValidation.NewLessEqualBaseVersion;
                        break;
                    case ValidateVersionComparison.TransformEqBase:
                        f = MsiTransformValidation.NewEqualBaseVersion;
                        break;
                    case ValidateVersionComparison.TransformGeBase:
                        f = MsiTransformValidation.NewGreaterEqualBaseVersion;
                        break;
                    case ValidateVersionComparison.TransformGrBase:
                        f = MsiTransformValidation.NewGreaterBaseVersion;
                        break;
                    default:
                        f = MsiTransformValidation.None;
                        break;
                }
                _validationFlags = _validationFlags.CombineFlags(f);
            }
        }

        private void SetErrorFlag(MsiTransformError bitmask, bool flag)
            => _errorFlags = flag ? _errorFlags.CombineFlags(bitmask) : _errorFlags.RemoveFlags(bitmask);

        private void SetValidationFlag(MsiTransformValidation bitmask, bool flag)
            => _validationFlags = flag ? _validationFlags.CombineFlags(bitmask) : _validationFlags.RemoveFlags(bitmask);

        /// <summary>
        /// Transform validation flags
        /// </summary>
        [Flags]
        private enum MsiTransformValidation : ushort
        {
            None = 0,
            Language = 1,
            Product = 2,
            MajorVersion = 8,
            MinorVersion = 0x10,
            UpdateVersion = 0x20,
            NewLessBaseVersion = 0x40,
            NewLessEqualBaseVersion = 0x80,
            NewEqualBaseVersion = 0x100,
            NewGreaterEqualBaseVersion = 0x200,
            NewGreaterBaseVersion = 0x400,
            AllVersionPartFlags= MajorVersion | MinorVersion | UpdateVersion,
            AllVersionComparisonFlags= NewLessBaseVersion | NewLessEqualBaseVersion | NewEqualBaseVersion | NewGreaterEqualBaseVersion | NewGreaterBaseVersion,
            UpgradeCode = 0x800,
            All = 0xffff
        };

        /// <summary>
        /// Transform error condition flags
        /// </summary>
        [Flags]
        private enum MsiTransformError : ushort
        {
            None = 0,
            AddExistingRow = 1,
            DelMissingRow = 2,
            AddExistingTable = 4,
            DelMissingTable = 8,
            UpdateMissingRow = 0x10,
            ChangeCodepage = 0x20,
            All = 0xffff
        };

        //public override bool Equals(object obj)
        //{
        //    //override Equals and write code to actually
        //    //test for equality so that the Custom created
        //    //from the call to ConvertFrom will be equal to
        //    //the field you created

        //    if (object.ReferenceEquals(obj, this)) {
        //        return true;
        //    }
        //    dynamic other = obj as TransValidData;
        //    if (other == null) {
        //        return false;
        //    }
        //    return this.FErrors == other.FErrors && this.FValidation == other.FValidation;
        //}

    }

    internal class CustomConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
            => destType == typeof(string) || base.CanConvertTo(context, destType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            //this is the method that is called when you specify a default value
            //for your type. you will need to add code to convert a string
            //representation to your object

            if (value is string s)
                // if (context==null)
                return new TransformValidationFlags(s);
            // else
            //    context.PropertyDescriptor.SetValue()

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var p = (TransformValidationFlags)value;
            return destinationType == typeof(string) ? p.ToString() : base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
