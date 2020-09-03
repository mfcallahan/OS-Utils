# This script is run on "Publish" configuration to delete existing output files
if [ -d $1 ]; then rm -rf $1; fi