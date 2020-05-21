#!/bin/sh

if [[ $EUID -ne 0 ]]; then
    echo "This script must be run as root"
    exit 1
fi

read -p "Continue deleting Iot Edge? (y/n) " choice
case "$choice" in
    [Yy]* )
        ret=$(sudo apt-get -y remove --purge iotedge)
        echo "uninstalled iot edge"
        ret=$(sudo apt-get -y remove --purge moby-cli)
        echo "uninstalled moby cli"
        ret=$(sudo apt-get -y remove --purge moby-engine)
        echo "uninstalled moby engine";;
    [Nn]* )
        echo "Canceled";;
    * )
        echo "Please choose Y or N";;
esac
