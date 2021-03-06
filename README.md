# dotnetlink
Linux network interface management tools with .NET Core and PowerShell interfaces

## Compatibility
These tools are created and tested on version 5.4 of the linux kernel using .NET Core 3.1 and PowerShell Core 7.0

## Features
### Routing (IPv4)
* Get the current routing table
* Add a route to the routing table
* Remove a route from the routing table

### Address management (IPv4)
* Get the current addresses assigned to interfaces
* Add an IPv4 address to an interface
* Remove an IPv4 address from an interface

### Interface management
* Get link details
* Set link to up or down
* Add VLAN subinterface
* Remove network interface

## Build

From the root directory of the repository in a PowerShell terminal

```
. Build.ps1
Build-DotNetLink
```

This will create a "Build" folder with the PowerShell module and the .NET interface 

## Docker

The dockerfile creates a docker container based on ubuntu with .NET Core 3.1 and PowerShell Core 7. PowerShell opens on container start up and the dotnetlinkps module is imported by the PowerShell profile

### Create the container
```
docker build -t dotnetlinkps .
```

### Run the container
```
docker run --rm -it --cap-add=CAP_NET_ADMIN --net=host dotnetlinkps
```

CAP_NET_ADMIN is only required if changes are to be made to the network setup. Get commands do not require this.