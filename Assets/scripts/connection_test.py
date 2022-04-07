#!/usr/bin/env python

from pythonosc import udp_client
import time
import math
import sys

client = udp_client.SimpleUDPClient('127.0.0.1', 7899)

i = 1

while True:
    try:
        client.send_message("/sensor/one", i)
        client.send_message("/sensor/two", i)
        if i > 0:
            i = i+1000
            if i > 16000:
                i = -1
        elif i < 0:
            i = i-1000
            if i < -16000:
                i = 1
        time.sleep(0.1)
        print(i)
    except KeyboardInterrupt:
        sys.exit()

