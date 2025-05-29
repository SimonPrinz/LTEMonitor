# LTEMonitor

Software to monitor the status of a LinkHub LTE modem via Prometheus and Grafana.

## Usage

```yaml
services:
  lte_exporter:
    image: ghcr.io/simonprinz/ltemonitor:latest
    restart: unless-stopped
    ports:
      - "8080:8080"
    environment:
      - "Config__Url=http://<your_modem_ip>/" # in most cases this is 192.168.1.1
      # EncryptionKey and RequestVerificationKey must be extracted from the JavaScript code at:
      # http://<your_modem_ip>/dist/build.js
      - "Config__EncryptionKey=" # search for ".encrypt=", there should be a long string somewhere
      - "Config__RequestVerificationKey=" # search for "_TclRequestVerificationKey="
      # - "Config__Username=admin" # optional, default is 'admin'
      - "Config__Password=<your_password>"
      # uncomment enable debug logs
      # - "Logging__LogLevel__SimonPrinz.LTE=Debug"
```

## Metrics

```prototext
connection_bytes{direction="upload"} 1061476
connection_bytes{direction="download"} 1572919
connection_rate{direction="upload"} 50000000
connection_rate{direction="download"} 100000000
connection_speed{direction="upload"} 85
connection_speed{direction="download"} 96
connection_status 2
connection_time{ipv4="123.234.213.132",ipv6="2a02::5a5f"} 6060
lan_status{ipv4="192.168.1.100",mac="xx:xx:xx:xx:xx:xx"} 1
network_signal{type="rssi"} -63
network_signal{type="rsrp"} -92
network_signal{type="sinr"} 16
network_signal{type="rsrq"} -10
system_uptime 1473851
```

## Screenshot

![LinkHub Screenshot](screenshot/LinkHub.png)
