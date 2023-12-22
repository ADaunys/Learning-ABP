#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p ad66a01a-fd5f-424d-958c-ed978b836794 -t
    fi
    cd ../
fi

docker-compose up -d
