function Build-DotNetLink
{
param(
    $SourcesRoot = (Get-Location),
    $OutputLocation = "$(Get-Location)/Build",
    [switch]$Release
)
    $PWD = Get-Location
    ### Configuration
    $ConnectorLocation = "$SourcesRoot/Connector"
    $ConectorBuildType = $Release.IsPresent ? "Release" : "Debug"
    $InterfaceLocation = "$SourcesRoot/Interface"

    if(-not (Test-Path $OutputLocation))
    {
        New-Item $OutputLocation -Type "directory"
    }


    if(-not (Test-Path "$OutputLocation/Connector"))
    {
        New-Item -Path $OutputLocation -Name "Connector" -Type "directory"
    }



    ### Compile the connector
    if(Test-Path $ConnectorLocation)
    {
        Set-Location "$OutputLocation/Connector"
        ## Call cmake
        cmake -DCMAKE_BUILD_TYPE=$ConectorBuildType $ConnectorLocation
        ## Call make
        make -j $(nproc)
    }
    else
    {
        return
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
        Copy-Item -Path "$OutputLocation/Connector/libdotnetlinkconnector.so" -Destination "$OutputLocation/Interface/libdotnetlinkconnector.so"
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
    Copy-Item -Path "$OutputLocation/Interface/libdotnetlinkconnector.so" -Destination "libdotnetlinkconnector.so"
    New-ModuleManifest -Author "Ellis Judge" -CmdletsToExport (Get-Content "$InterfaceLocation/dotnetlinkps/ExportedFunctions.txt") -Path "dotnetlinkps.psd1" -RootModule "dotnetlinkps.dll" -Copyright "Released under MIT license" 

    ### Create a package for dotnet inclusion
    Remove-Item "$OutputLocation/Interface/dotnetlinkps.dll"

    Remove-Item "$OutputLocation/Connector" -Recurse


    Set-Location $PWD
}