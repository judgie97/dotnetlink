###############################
###     Base
###############################

FROM ubuntu:focal as base

RUN apt update
RUN apt install -y apt-transport-https
RUN apt install -y curl libicu-dev


###############################
###     SDK
###############################
FROM base as sdk

WORKDIR /dotnet
RUN curl -sL https://download.visualstudio.microsoft.com/download/pr/f65a8eb0-4537-4e69-8ff3-1a80a80d9341/cc0ca9ff8b9634f3d9780ec5915c1c66/dotnet-sdk-3.1.201-linux-x64.tar.gz -o dotnet.tar.gz
RUN tar -xf dotnet.tar.gz
RUN rm dotnet.tar.gz

WORKDIR /powershell
RUN curl -sL https://github.com/PowerShell/PowerShell/releases/download/v7.0.0/powershell-7.0.0-linux-x64.tar.gz -o powershell.tar.gz
RUN tar -xf powershell.tar.gz
RUN rm powershell.tar.gz

RUN mkdir -p /opt/microsoft/powershell

RUN mv /powershell /opt/microsoft/powershell/7.0.0
RUN mv /dotnet /opt/microsoft/dotnet

RUN ln -s /opt/microsoft/dotnet/dotnet /usr/bin/dotnet
RUN ln -s /opt/microsoft/powershell/7.0.0/pwsh /usr/bin/pwsh

###############################
###     Runtime
###############################

FROM base as runtime

WORKDIR /dotnet
RUN curl -sL https://download.visualstudio.microsoft.com/download/pr/c1d419e7-4312-4464-b272-27bee7676560/22e7bb584ff56f3089c85d98b21c0445/dotnet-runtime-3.1.3-linux-x64.tar.gz -o dotnet.tar.gz
RUN tar -xf dotnet.tar.gz
RUN rm dotnet.tar.gz

WORKDIR /powershell
RUN curl -sL https://github.com/PowerShell/PowerShell/releases/download/v7.0.0/powershell-7.0.0-linux-x64.tar.gz -o powershell.tar.gz
RUN tar -xf powershell.tar.gz
RUN rm powershell.tar.gz

RUN mkdir -p /opt/microsoft/

RUN mv /powershell /opt/microsoft/powershell
RUN mv /dotnet /opt/microsoft/dotnet

RUN ln -s /opt/microsoft/dotnet/dotnet /usr/bin/dotnet
RUN ln -s /opt/microsoft/powershell/pwsh /usr/bin/pwsh

###############################
###     Compile
###############################

FROM sdk as build-env

WORKDIR /compile
COPY ./src/ ./src/
COPY ./Build.ps1 ./Build.ps1

RUN pwsh -C ". ./Build.ps1; Build-DotNetLink"

###############################
###     dotnetlinkps
###############################

FROM runtime

RUN apt install -y libnl-route-3-200 nftables

RUN ln -s /lib/x86_64-linux-gnu/libnl-3.so.200 /lib/x86_64-linux-gnu/libnl-3.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libnl-route-3.so.200 /usr/lib/x86_64-linux-gnu/libnl-route-3.so

ENV DOTNET_ROOT=/opt/microsoft/dotnet/

COPY --from=build-env /compile/Build/PowerShell/ /opt/microsoft/powershell/Modules/dotnetlinkps/

RUN mkdir -p /root/.config/powershell

RUN echo "Import-Module dotnetlinkps" > /root/.config/powershell/Microsoft.PowerShell_profile.ps1

WORKDIR /root
ENTRYPOINT ["pwsh"]