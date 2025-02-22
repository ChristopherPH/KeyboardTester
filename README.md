# Keyboard Tester

This is a test program to demonstrate how to hijack windows keypresses to be better suited for a gaming application.

Goals:
- Capture key down and key up events before they are processed by Windows
- Handle the numeric keypad unshifting functionality when numlock is on

## Notes

- Keyboard event order
  - Key Down
    - `ProcessCmdKey()` (used for processing shortcut keys)
    - `ProcessKeyPreview()`
    - `OnKeyDown()`
  - Key Up
    - `ProcessKeyPreview()`
- For the Key Down events, any time a method returns true, the event chain stops processing
- `ProcessKeyPreview()` only triggers when there are controls on the form
- Form level `OnKeyDowm()` and `OnKeyUp()` events only trigger when the form `KeyPreview` property is set to true
  - This is a VB6 compatibility property, and should be avoided when possible
