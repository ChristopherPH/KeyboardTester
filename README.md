# Keyboard Tester

This is a test program to demonstrate how to hijack windows keypresses to be better suited for a gaming application.

Goals:
- Capture key down and key up events before they are processed by Windows
- Handle the numeric keypad unshifting functionality when numlock is on

## Known Issues

- Numlock on, using standard windows behaviour
  - ERROR: Released NumPad4 without associated press (this is expected with default handling)
    - Hold shift
    - Hold ctrl
    - Hold num left
    - Unpress ctrl
    - Unpress shift (before repeat delay elapses)
    - Unpress num left (before repeat delay elapses)

Holding down both shift keys can generate errors

- Numlock on, using adjustment mode of `Shift`
  - ERROR: Released NumPad4 without associated press
    - Hold left shift
    - Hold right shift
    - Hold num left
    - Unpress left shift
    - Unpress right shift
    - Unpress num left

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
- Using RawInput and SetWindowsHookEx only works when hooking WH_KEYBOARD, not WH_KEYBOARD_LL
- Good keyboard stack overflow answers from Hans Passant:
  - https://stackoverflow.com/questions/26158578/what-is-the-purpose-of-all-process-methods-and-all-messages-filters
