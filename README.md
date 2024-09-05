# taitctrl

Control the channel (and maybe more) of a Tait 8000-series radio.

If you find this useful, please feel free to [![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Y8Y8KFHA0), but no pressure of course.

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

## Radio Configuration

On the Data tab of the radio programming application, ensure the radio has Data Port set to Aux (15-pin accessory connector), Mic (front panel RJ45), or Internal Options as required. Set the Command Mode Baud Rate to 28800 (or the rate you specify when opening the serial port).

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
