#!/bin/bash
wd=$(pwd)

# Restore
cd $wd/ParamParam
dotnet restore

cd $wd/ParamParamTests
dotnet restore

# Build
cd $wd/ParamParam
dotnet build

cd $wd/ParamParamTests
dotnet build
