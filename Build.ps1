function Build-DotNetLink
{
param(
    $SourcesRoot = (Get-Location),
    $OutputLocation = "$(Get-Location)/Build",
    [switch]$Release
)
    $PWD = Get-Location
    ### Configuration
    $InterfaceLocation = "$SourcesRoot/src"

    if(-not (Test-Path $OutputLocation))
    {
        New-Item $OutputLocation -Type "directory"
    }

    ### Compile the Interfaces
    if(Test-Path $InterfaceLocation)
    {
        Set-Location $InterfaceLocation
        dotnet restore
        dotnet build

        if(-not (Test-Path "$OutputLocation/Interface"))
        {
            New-Item -Path $OutputLocation -Name "Interface" -type "directory"
        }

        Copy-Item -Path "$InterfaceLocation/dotnetlinkps/bin/Debug/netcoreapp3.1/dotnetlinkps.dll" -Destination "$OutputLocation/Interface/dotnetlinkps.dll"
        Copy-Item -Path "$InterfaceLocation/dotnetlinkps/bin/Debug/netcoreapp3.1/dotnetlink.dll" -Destination "$OutputLocation/Interface/dotnetlink.dll"
        Copy-Item -Path "$InterfaceLocation/dotnetlinkps/bin/Debug/netcoreapp3.1/libnl.dll" -Destination "$OutputLocation/Interface/libnl.dll"
		Copy-Item -Path "~/.nuget/packages/newtonsoft.json.schema/3.0.13/lib/net45/Newtonsoft.Json.Schema.dll" -Destination "$OutputLocation/Interface/Newtonsoft.Json.Schema.dll"
    }
    else
    {
        return
    }
    

    ### Create a powershell module
    If(-not (Test-Path "$OutputLocation/PowerShell"))
    {
        New-Item -Path $OutputLocation -Name "PowerShell" -Type "directory"
    }

    Set-Location "$OutputLocation/PowerShell"
    Copy-Item -Path "$OutputLocation/Interface/dotnetlinkps.dll" -Destination "dotnetlinkps.dll"
    Copy-Item -Path "$OutputLocation/Interface/dotnetlink.dll" -Destination "dotnetlink.dll"
    Copy-Item -Path "$OutputLocation/Interface/libnl.dll" -Destination "libnl.dll"
    Copy-Item -Path "$OutputLocation/Interface/Newtonsoft.Json.Schema.dll" -Destination "Newtonsoft.Json.Schema.dll"
    $commands = (Get-Content "$InterfaceLocation/dotnetlinkps/ExportedFunctions.txt") | Where-Object{ -not $_ -like "#*"}
    New-ModuleManifest -Author "Ellis Judge" -CmdletsToExport $commands -Path "dotnetlinkps.psd1" -RootModule "dotnetlinkps.dll" -Copyright "Released under MIT license" 

    ### Create a package for dotnet inclusion
    Remove-Item "$OutputLocation/Interface/dotnetlinkps.dll"

    Set-Location $PWD
}
