#! /bin/bash

# Sample to show files in directory
# for f in /directory/* ; do echo ${f}; done

# stores
for f in /stores/* ; do echo ${f}; mongoimport --host mongo --db Cart --collection stores --type json --file ${f} --jsonArray --upsert; done
