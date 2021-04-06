# XKeyboard
Fancy fonts for physical keyboard on windows

XKeyboard is a tool created for Windows to provide fancy fonts / text while typing on the physical keyboard.

The application intercepts (blocks) actual keyboard input and sends custom keystrokes to any active application giving users an option to 
use custom (or pre-defined) font sets.

XKeyboard uses a low-level keyboard procedure and hooks with the keyboard through windows user32.dll. 
So, all the keys (even control modifiers) are reported to this application. 
However, other physical keys (i.e. toggle-airplane key in laptops) aren’t reported or modified. 
When the application receives a key event, it blocks the actual keyboard input and sends custom keys instead. 
The application uses a class database (which is, serialized and saved in XML format) to store custom characters for each key on the keyboard which 
is sent to the windows instead of standard ASCII characters.

# Built-in Fonts
XKeyboard comes with 15+ pre-defined fonts. You can also create your own font set or modify the existing font sets using Font Editor.

List of pre-defined font sets:

D̴e̴c̴o̴r̴a̴t̴e̴d̴ 1̴
D҉e҉c҉o҉r҉a҉t҉e҉d҉ 2҉
Ｅｘｔｅｎｄｅｄ Ａ
E x t e n d e d B
Sƚყʅιʂԋ 1
ʂƚყʅιʂԋ 2
S̶t̶r̶o̶k̶e̶d̶
S̷c̷r̷a̷t̷c̷h̷e̷d̷
U̲n̲d̲e̲r̲l̲i̲n̲e̲d̲ 1
U̳n̳d̳e̳r̳l̳i̳n̳e̳d̳ 2̳
ⓦ𝐞𝓲г∂ ❶
ᗯ€Ꭵʳ𝔡 ➁Ŝŧřâňĝē
ⓒⓘⓡⓒⓛⓔⓢ
【B】【r】【a】【c】【k】【e】【t】【s】
𝐛𝐨𝐥𝐝 𝐀
𝗯𝗼𝗹𝗱 𝗕
🄱🄾🅇🄴🅂 (🅆🄷🄸🅃🄴)
🅱🅾🆇🅴🆂 (🅷🅸🅶🅷 🅲🅾🅽🆃🆁🅰🆂🆃)
..+ All the font sets are customizable.

# LICNSE
Copyright 2021 Zexware, Ltd.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
