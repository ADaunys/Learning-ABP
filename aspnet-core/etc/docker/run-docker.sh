#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p d505acba-0d09-41a0-b488-cbd58ed4ad97 -t
    fi
    cd ../
fi

docker-compose up -d
