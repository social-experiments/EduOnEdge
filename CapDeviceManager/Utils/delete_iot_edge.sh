#!/bin/sh

read -p "Continue deleting Iot Edge? (y/n) " choice
case "$choice" in
    [Yy]* )
        ret=$(echo <password> | sudo -S apt-get -y remove --purge iotedge)
        echo "uninstalled iot edge"
        ret=$(echo <password> | sudo -S apt-get -y remove --purge moby-cli)
        echo "uninstalled moby cli"
        ret=$(echo <password> | sudo -S apt-get -y remove --purge moby-engine)
        echo "uninstalled moby engine";;
    [Nn]* )
        echo "Canceled";;
    * )
        echo "Please choose Y or N";;
esac