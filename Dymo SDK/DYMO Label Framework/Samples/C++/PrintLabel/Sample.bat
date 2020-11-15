@rem print on LabelWriter Twin Turbo
PrintLabel.exe /printer "DYMO LabelWriter Twin Turbo" /tray 2 /copies 1 /objdata "Address=1%202%203" "Address.label"

@rem print on tape printer
PrintLabel.exe /printer "DYMO LabelWriter DUO Tape 128" /copies 1 /objdata "Address=1%202%203" "19mm.label"