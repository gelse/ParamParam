#!/bin/bash
wd=$(pwd)

# Restore
cd $wd/ParamParam
dotnet restore

cd $wd/ParamParamTest
dotnet restore

# Build
cd $wd/ParamParam
dotnet build

cd $wd/ParamParamTest
dotnet build
