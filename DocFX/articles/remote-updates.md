---
uid: remote_updates
---

# Remote Updates

After configuring [push notifications](xref:push_notifications), it is possible
to send protocol update commands to devices. This article describes the updates
that are directly supported:

  * Polling delay tolerance:  Use the following command within the home directory of your 
  push notification backend to update the <xref:Sensus.Probes.PollingProbe.DelayToleranceBeforeMS> and
  <xref:Sensus.Probes.PollingProbe.DelayToleranceAfterMS> values:
  
  ```
  ./list-devices.sh BUCKET | ./set-delay-tolerance.sh MS_BEFORE MS_AFTER MESSAGE
  ```
  
  where `BUCKET` is the S3 bucket name, `MS_BEFORE` is the new value for <xref:Sensus.Probes.PollingProbe.DelayToleranceBeforeMS>,
  `MS_AFTER` is the new value for <xref:Sensus.Probes.PollingProbe.DelayToleranceAfterMS>, and `MESSAGE`
  is a message to display to the user to notify them of the update. 
  
The above commands are the only ones that are directly supported; however, the remote update 
capability is entirely generalized. See the [scripts](https://github.com/predictive-technology-laboratory/sensus/tree/develop/Scripts/ConfigureAWS/push-protocol-updates)
for how to extend the above set of commands to update any settings of interest.