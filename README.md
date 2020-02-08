# dotnetlink
Linux network interface and firewall management tools with .NET Core and PowerShell interfaces

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

### Firewall management
* Get the current filter rules
* Add new filter rules
* Remove filter rules 