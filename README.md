# Ghooks
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/402f9dbee0514e1fb71a2c69a23c4315)](https://app.codacy.com/manual/benhaim.ido/Ghooks?utm_source=github.com&utm_medium=referral&utm_content=ggggg/Ghooks&utm_campaign=Badge_Grade_Dashboard)[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)


<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
  * [Installation](#installation)
  * [Usage](#usage)
    * [Basic Usage](#basic-usage)
    * [Embeds](#embeds)
    * [Events](#events)
* [Contact](#contact)

<!-- ABOUT THE PROJECT -->
## About The Project
This plugin allows you to connect a Broke Protocol server to discord webhooks without any 3rd party api or any other programs.

Things you can do with it:
* Make logs in your discord for easier moderation.
* Send messages to players
* Hook to custom events and send messages 


## Getting Started

### Installation

1. Download the plugin from the steam workshop or from the latest [release](https://github.com/ggggg/Ghooks/releases).
2. Run the server once in order to get the needeed files.
3. Open the newly created folder named "GHooks" and edit the settings.json.


### Usage
#### **Basic usage:**

This is an example on how to change an existing event. (We are using the server start event)

```json
"ServerStart": "",
```
This is where the webhook link should be, if you don't want this event to run just leave it empty.
#
```json
"ServerStartMessage": "Server started",
```
This is the message that will be sent to the webhook. In other events you can use {0} and {1} to add player name and message they are sending.
#
```json
"ServerStartUseEmbed": true,
```
This is the option that enables or disables embeds for the webhook; it can be either true or false.
#
#### **Embeds:**

Embeds allow you to give a nice style and color to your webhook messages. You can use up to 10 embeds to send your message. 
I only recommend adding new embeds if you understand what you're doing, else you can edit the default ones as you want.
#
```json5
"ServerStartEmbed": [{
  //Here will be Embed #1
}]
```
Embeds will be inside this option as a list, to add a new embed you need to add a comma **(,)** after the closing bracket and open a new one where you'll place the same settings:
```json5
"ServerStartEmbed": [{
  //Here will be Embed #1
},
{
  //Here will be Embed #2
}]
```
#
Inside each embed there should be the next options:
```json
"title": "Server Started",
"type": "rich",
"description": "Server has started",
"url": null,
"timestamp": null,
"color": 15158332,
"footer": {
   "text": "Example footer",
   "icon_url": null,
   "proxy_icon_url": null
},
"image": {
   "height": 0,
   "width": 0,
   "proxy_url": null,
   "url": null
},
"thumbnail": {
   "height": 0,
   "width": 0,
   "proxy_url": null,
   "url": null
},
"video": {
   "height": 0,
   "width": 0,
   "url": null
},
"provider": {
   "name": null,
   "url": null
},
"author": {
   "name": "Example author",
   "icon_url": "https://emoji.gg/assets/emoji/5812_yeetus.png",
   "proxy_icon_url": null,
   "url": null
},
"fields": [{
   "name": "Example field",
   "value": "Example field description",
   "inline": false
}]
```
Notes:
- Titles can only have 256 characters.
- Description can only have 2048 characters.
- There can be up to 25 fields.
- Color uses decimal value.
#
#### **Events:**
You can hook your webhook to a custom event. To do that you must edit the customEvents.json file following this format:
```json5
[
    {
        "SenderName" : "{0}", // {0} is the user name

        "Event" : "EXAMPLE_EVENT", // This is the name of the event you'll be hooking to

        "webhookLink" : "", // Here goes the webhook link

        "Response" : "{0} has went in the triggerbox" 
        //This is the message that will be sent
    }
    
]
```
## Contact
The-g - [GitHub](https://github.com/ggggg) - Discord: The-g#7731

xiluisx - [GitHub](https://github.com/xiluisx) - Discord: xiluisx#1092

