VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DbUserValidator"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

' This class implements IVehicle.
Implements IUserValidator

' Delegates most functions to this object.
Private m_UserValidatorBase As IUserValidator

' Instantiate the UserValidatorBase.
Private Sub Class_Initialize()
    Set m_UserValidatorBase = New UserValidatorBase
End Sub

' Dispose
Private Sub Class_Terminate()
    Set m_UserValidatorBase = Nothing
End Sub

'User validation specific to DBUserValidation
Public Function IUserValidator_IsUserValid(ByVal username As String, password As String) As Boolean
  IUserValidator_IsUserValid = username <> "" And password <> "" And Len(password) > 8
End Function
