# This script can be run on "Publish" configuration to delete the existing output directory.
# The "Delete Existing Files" publish option found in Visual Studio is not available in Rider, but
# has been requested: https://youtrack.jetbrains.com/issue/RIDER-38272
if [ -d "$1" ]; then rm -rf "$1"; fi