#!/bin/bash
if [[ $EUID -ne 0 ]]; then
    echo "This script must be run as root"
    exit 1
fi

# Install IoT Edge Runtime - Ubuntu 18.04
ret=$(curl https://packages.microsoft.com/config/ubuntu/18.04/multiarch/prod.list > ./microsoft-prod.list)

# Generated list
ret=$(sudo cp ./microsoft-prod.list /etc/apt/sources.list.d/)

# Install Microsoft GPG public key
ret=$(curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg)

ret=$(sudo cp ./microsoft.gpg /etc/apt/trusted.gpg.d/)

#ret=$(sudo apt-get update)
ret=$(sudo apt-get update)
echo refreshed
ret=$(sudo apt-get -y install moby-engine)
echo "installed moby-engine"
ret=$(sudo apt-get -y install moby-cli)
echo "installed moby-cli"
ret=$(sudo apt-get -y install iotedge)
echo "installed iot-edge"

# Make back-up for testing
ret=$(sudo cp /etc/iotedge/config.yaml /etc/iotedge/config.yaml_backup)

# Edit to add connection string

ret=$(sudo sed -i "s#\(\"<ADD DEVICE CONNECTION STRING HERE>\"\).*#\"$1\"#g" /etc/iotedge/config.yaml)
echo "added connection string"

# Restart daemon
ret=$(sudo systemctl restart iotedge)
echo "daemon restarted"
echo "IoT Edge sucessfully installed and configured"
