# PowerComposer
Enhanced Composer for Fiddler.

<img src="https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/ss.PNG" width="500" height="500" alt="screenshot" >

# Features

- Variable sequence
- Number sequence
- File inclusion

# Usage

## Basic

1. Select "Builder" tab.
2. Edit textboxes as with Composer.
3. Click "Execute" button to send your original requests.

## Variable sequence

### Register variables

1. Select "Variables" tab.
2. Input variable name into the form below.
3. press the Enter key or click Add button.
4. press Enter again or click the name you registered from Variables list.
5. Input variable values. (Newline-delimited)

<img src="https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/var1.PNG" width="500" height="500" alt="Register variables" >
### Use registered variable

You can use ${} statement.
Input variable name in {}.

```
${SearchIndex}
```

<img src="https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/var2.PNG" width="500" alt="Use register variables" >

It will be expanded sequentially when sending requests.

<img src="https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/var3.PNG" width="500" alt="Sent Requests" >

## Number sequence

You can use #{} statement.
Input number sequence in {}.

```
#{1-9}
```
![Use registered variable](https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/Eseq.PNG)

It will be expanded when sending requests. 1, 2, 3, 4, ..., 8, 9.

![Use registered variable](https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/Rseq.PNG)

```
#{9-1}
```

It will be 9, 8, 7, 6, ..., 2, 1. (Reversed)

## File inclusion

You can use !{} statement.
Input File path in {}.

```
!{C:\xxx\test.txt}
```

![Use registered variable](https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/Efi.PNG)

It will be expanded when sending requests.

![Use registered variable](https://raw.githubusercontent.com/takubokudori/PowerComposer/master/images/Rfi.PNG)

## Copy HTTP request from web sessions.

Drag & Drop a web session to Builder tab or choose "Reissue from PowerComposer" from context menu.

# License
This software is released under the MIT License, see LICENSE.
