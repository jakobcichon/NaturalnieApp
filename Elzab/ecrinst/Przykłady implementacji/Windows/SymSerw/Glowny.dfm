object GlowneOknoAplikacji: TGlowneOknoAplikacji
  Left = 224
  Top = 230
  Width = 607
  Height = 297
  Caption = 'Symulator serwera kasowego'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = TworzenieGlownegoOkna
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 3
    Height = 13
  end
  object Panel2: TPanel
    Left = 24
    Top = 96
    Width = 257
    Height = 137
    TabOrder = 18
  end
  object Panel1: TPanel
    Left = 304
    Top = 96
    Width = 265
    Height = 137
    TabOrder = 17
  end
  object GroupBox1: TGroupBox
    Left = 24
    Top = 16
    Width = 185
    Height = 73
    Caption = 'KOMUNIKAT WINDOWS'
    TabOrder = 1
    object Label2: TLabel
      Left = 8
      Top = 24
      Width = 40
      Height = 13
      Caption = 'NUMER'
    end
    object Label3: TLabel
      Left = 8
      Top = 48
      Width = 86
      Height = 13
      Caption = 'IDENTYFIKATOR'
    end
    object Edit2: TEdit
      Left = 104
      Top = 40
      Width = 73
      Height = 21
      TabOrder = 0
      Text = '654321'
      OnChange = ObliczenieIdentyfikatoraKomunikatu
    end
  end
  object Edit1: TEdit
    Left = 128
    Top = 32
    Width = 73
    Height = 21
    TabOrder = 0
    Text = '123456'
    OnChange = ObliczenieNumeruKomunikatu
  end
  object Button5: TButton
    Left = 312
    Top = 104
    Width = 97
    Height = 25
    Caption = 'COUNT'
    TabOrder = 6
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 312
    Top = 136
    Width = 97
    Height = 25
    Caption = 'LINES'
    TabOrder = 7
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 312
    Top = 168
    Width = 97
    Height = 25
    Caption = 'OUTLINES'
    TabOrder = 8
    OnClick = Button7Click
  end
  object Button8: TButton
    Left = 312
    Top = 200
    Width = 97
    Height = 25
    Caption = 'WSZYSTKIE'
    TabOrder = 9
    OnClick = Button8Click
  end
  object StaticText5: TStaticText
    Left = 416
    Top = 112
    Width = 100
    Height = 17
    Caption = '                                '
    TabOrder = 14
  end
  object StaticText6: TStaticText
    Left = 416
    Top = 144
    Width = 100
    Height = 17
    Caption = '                                '
    TabOrder = 15
  end
  object StaticText7: TStaticText
    Left = 416
    Top = 176
    Width = 100
    Height = 17
    Caption = '                                '
    TabOrder = 16
  end
  object Button1: TButton
    Left = 32
    Top = 104
    Width = 97
    Height = 25
    Caption = 'SUSPEND'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 32
    Top = 136
    Width = 97
    Height = 25
    Caption = 'RESUME'
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 32
    Top = 168
    Width = 97
    Height = 25
    Caption = 'BREAK'
    TabOrder = 4
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 32
    Top = 200
    Width = 97
    Height = 25
    Caption = 'AVAILABLE'
    TabOrder = 5
    OnClick = Button4Click
  end
  object StaticText1: TStaticText
    Left = 136
    Top = 112
    Width = 100
    Height = 17
    Caption = '                                '
    TabOrder = 10
  end
  object StaticText2: TStaticText
    Left = 136
    Top = 144
    Width = 100
    Height = 17
    Caption = '                                '
    TabOrder = 11
  end
  object StaticText3: TStaticText
    Left = 136
    Top = 176
    Width = 100
    Height = 17
    Caption = '                                '
    TabOrder = 12
  end
  object StaticText4: TStaticText
    Left = 136
    Top = 208
    Width = 100
    Height = 17
    Caption = '                                '
    TabOrder = 13
  end
end
