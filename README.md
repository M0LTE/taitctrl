# taitctrl

Control the channel (and maybe more) of a Tait 8000-series radio.

## Usage

```
$ ./taitctrl
Usage: taitctrl <port> chan [n]
examples:
  taitctrl /dev/ttyUSB0 chan      -   get current channel
  taitctrl /dev/ttyUSB0 chan 1    -   set channel to 1

$ ./taitctrl /dev/ttyUSB0 chan
1

$ ./taitctrl /dev/ttyUSB0 chan 2

$ ./taitctrl /dev/ttyUSB0 chan
2
```
