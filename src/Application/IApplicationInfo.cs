namespace netHelpers.Framework.Application
{
    /// <summary>
    /// Contract to implement Application Provider. 
    /// </summary>
    interface IApplicationInfo
    {
        string Name { get; set; }
        string Version { get; set; }
        string Code { get; set; }
    }
}
