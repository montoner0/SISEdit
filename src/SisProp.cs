namespace sisedit
{
    internal enum SisProp
    {
        /// <summary>
        /// PID_CODEPAGE = code page for the summary information stream
        /// </summary>
        CodePage = 1,
        /// <summary>
        /// PID_TITLE = typically just "Transform"
        /// </summary>
        Title = 2,
        /// <summary>
        /// PID_SUBJECT = original subject of target
        /// </summary>
        Subject = 3,
        /// <summary>
        /// PID_AUTHOR = original manufacturer of target
        /// </summary>
        Author = 4,
        /// <summary>
        /// PID_KEYWORDS = keywords for the transform, typically including at least "Installer"
        /// </summary>
        Keywords = 5,
        /// <summary>
        /// PID_COMMENTS = describes what this package does
        /// </summary>
        Comments = 6,
        /// <summary>
        /// PID_TEMPLATE = target platform;language
        /// </summary>
        PlatformAndLanguage = 7,
        /// <summary>
        /// PID_LASTAUTHOR = Used for transforms only: New target: Platform(s);Language(s)
        /// </summary>
        UpdatedPlatformAndLanguage = 8,
        /// <summary>
        /// PID_REVNUMBER = {productcode}version;{newproductcode}newversion;upgradecode
        /// </summary>
        ProductCodes = 9,
        /// <summary>
        /// PID_LASTPRINTED = Date and time of installation image, same as Created if CD
        /// </summary>
        Printed = 11,
        /// <summary>
        /// PID_CREATE_DTM = the timestamp when the transform was created
        /// </summary>
        Created = 12,
        /// <summary>
        /// PID_LASTSAVE_DTM = Date and time of last package modification
        /// </summary>
        Saved = 13,
        /// <summary>
        /// PID_PAGECOUNT = Minimum Windows Installer version required: Major * 100 + Minor
        /// </summary>
        Schema = 14,
        /// <summary>
        /// PID_WORDCOUNT = Source flags: 1=short names, 2=compressed, 4=network image, 8=No elevated privileges
        /// required
        /// </summary>
        SourceFlags = 15,
        /// <summary>
        /// PID_CHARCOUNT = The upper word contains the transform validation flags. The lower word contains the
        /// transform error condition flags. This property should be Null in an installation package or patch
        /// package
        /// </summary>
        ValidationFlags = 16,
        /// <summary>
        /// PID_APPNAME = the application that created the transform
        /// </summary>
        CreatingApplication = 18,
        /// <summary>
        /// PID_SECURITY = 0=Read/write 1=Readonly recommended 2=Readonly enforced; should always be 4 for
        /// transforms
        /// </summary>
        Security = 19//,
                     //MaxProps=20
    }
}
