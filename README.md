# 3Commas.BulkEditor

This unofficial tool allows you to bulk edit your simple DCA bots.


## Technical description

The implementation is based on .Net Framework. I will probably upgrade to .NET 5 in November when ClickOnce will also be available for automatic updates.

Implementation is build upon the AdvancedDataGridView and 3Commas.Net library. Thanks for the brilliant work!

If you need something, [let me know](https://github.com/MarcDrexler/3Commas.BulkEditor/issues).

Also if you think something is broken or have any questions, please open an [Issue](https://github.com/MarcDrexler/3Commas.BulkEditor/issues).


## Features

- View all of your simple 3Commas bots
- Filtering, sorting, etc
- Bulk Edit of selected bots

## Screenshots

![Main Screen](https://github.com/MarcDrexler/3Commas.BulkEditor/blob/master/screenshots/Mainscreen.png)

![Edit Dialog](https://github.com/MarcDrexler/3Commas.BulkEditor/blob/master/screenshots/EditDialog.png)

![In Progress Dialog](https://github.com/MarcDrexler/3Commas.BulkEditor/blob/master/screenshots/InProgress.png)

## Prerequisites

- .NET Framework 4.7.2 (which already might be installed on your Windows machine)
- 3Commas API key and secret

**Note:** By default, API keys are not stored on your computer and must be entered again the next time the application is started. There is an option to persist ApiKey and Secret. However, use is at your own risk. Other programs could read this information.

## Installer

I use MS ClickOnce for installation and updates.

An installer with the current version is hosted [here](https://marcdrexler.blob.core.windows.net/bulkeditor/BulkEditor.application)

Updates are automatically checked for each start.

Because the package is not signed with a public certificate, you might see some security warnings when installing and starting the app if you are using Windows 7 or later.

## Support

I develop and maintain this package on my own for free in my spare time.
Donations are greatly appreciated and a motivation to keep improving.

XMR: 89rmrxDAGAWWhSZXhnNf335qYfyXz4vQsNAM1VFSg6Y7Tve9BGF9pwte9ps61E9FY76r4onhWw7e19eu7fM8BARQMRHNBt7

or

<a href="https://www.buymeacoffee.com/marcdrexler" target="_blank"><img width="136" height="40" src="https://cdn.buymeacoffee.com/buttons/v2/default-orange.png" alt="Buy Me A Coffee" style="height: 40px !important;width: 136px !important;" ></a>

