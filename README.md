# taitctrl

Control the channel (and maybe more) of a Tait 8000-series radio.

## Installation

### Linux
```
wget -q https://github.com/M0LTE/taitctrl/releases/download/v0.0.1/taitctrl-linux-arm64.zip
sudo apt install unzip
unzip taitctrl-linux-arm64.zip
cd taitctrl-linux-arm64
chmod +x taitctrl

$ sudo ./taitctrl /dev/ttyUSB0 chan
1
```

- Pick a binary as appropriate - releases  are [here](https://github.com/M0LTE/taitctrl/releases/)
- Pick the serial port device path as appropriate
- Move the binary to somewhere in your system path for convenience
- Put your user in a group with permission to access the serial port to avoid the need to sudo

Windows and macOS are pretty self-explanatory based on the above.

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

This uses [my Tait library](https://github.com/M0LTE/tait-ccdi).

Someone could probably trivially rewrite this in C for a much smaller binary, details are in [the protocol manual](https://wiki.oarc.uk/_media/radios:tm8100-protocol-manual.pdf) - be my guest :)
