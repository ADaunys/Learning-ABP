#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 00b8310f-5046-4290-ae51-1fa2f045f06c -t
    fi
    cd ../
fi

docker-compose up -d
