# EduOnEdge
Offline Content Access


### Instructions on publishing
 * Make sure to configure the correct IP address in the Program.cs file
 * Run the following command from the root folder if on an ubuntu 18.04-x64 machine,
    otherwise change the runtime evnironment:

 ```dotnet publish CapDeviceManager.sln -c Release -r ubuntu.18.04-x64```

##Instructions on developing on Ubuntu

Instructions on configuring and running CapDeviceManager on a linux machine 

## Downloads

1. Download dotnet SDK for Ubuntu 18.04 using these commands 

```
wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

```
sudo add-apt-repository universe
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1 
```
More information about the installation is included [here](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#1604-)

2. Download monodevelop in order to build the project [here](https://www.monodevelop.com/download/#fndtn-download-lin)

3. Follow the manual install instructions for Azure CLI displayed [here](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-apt?view=azure-cli-latest#manual-install-instructions)

## Instructions To Run Project from MonoDevelop

1. Open the Project on MonoDevelop and configure build option
  * First, go to Edit > Preferences> Projects> SDK Locations > .NET CORE
  * Right click on CapDeviceManager in the explorer view in MonoDevelop and click on Restore NuGet Packages
  * Click on the 3 dots on the right side of the location input field
  * Go to /usr/share/dotnet/dotnet and choose it.
  * Close preferences and rebuild the project

2. Run the project, if the browser doesn't open up, manually go to 
```
https://<IPv4 Address of your computer>:5001
```

## Running the project from the terminal 
1. Open up the terminal and navigate to the EduOnEdge folder

2. Run the following commands: 

```
dotnet restore

dotnet msbuild CapDeviceManager.sln
```
3. Navigate to the CapDeviceManager folder and run following command to run project

```
dotnet run CapDeviceManager.csproj
```

4. The terminal should show the link at "Now listening on:...". The link should be in the form
```
https://<IPv4 Address of your computer>:5001
```

5. 
- If used on Firefox, click on Advance > Add Exception > Confirm Security Exception, and the webpage should show up
- If used on Chrome, click on Advance > Proceed[...]

6. To stop the program, Type Ctrl + C in the terminal that deploys the program

=======
# Prerequite
Please install azure CLI on machine where you are trying this project.
Make sure az verion is 2.1.* and above, and add extension with command:
	az extension add --name azure-cli-iot-ext

