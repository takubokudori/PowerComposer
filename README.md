# PowerComposer
Enhanced Composer for Fiddler.

# Features

- Variable sequence
- number sequence
- file inclusion

# Usage

## Variable sequence

### Register variable

1. Select "Variables" tab.
2. Input variable name into the form below.
3. press the Enter key or click Add button.
4. press Enter again or click the name you registered above.
5. Input variable values. (Newline-delimited)

### Use variable

You can use ${} statement.
Input variable name in {}.

```
${test}
```

It will be expanded sequentially when sending requests.

## Number sequence

You can use #{} statement.
Input number sequence in {}.

```
#{1-9}
```

It will be expanded when sending requests. 1, 2, 3, 4, ..., 8, 9.

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

It will be expanded when sending requests.

## Copy HTTP request from web sessions.

Drag & Drop a web session to Builder tab or choose "Reissue from PowerComposer" from context menu.

# License
This software is released under the MIT License, see LICENSE.
