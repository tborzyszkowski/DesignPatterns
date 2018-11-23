from window_error_concrete_builder import WindowError
from window_info_concrete_builder import WindowInfo
from window_warning_concrete_builder import WindowWarning
from message_director import Message


def main():
    message = Message()

    error = message.build(WindowError())
    error.getWindow()

    print('\n')

    info = message.build(WindowInfo())
    info.getWindow()

    print('\n')

    warning = message.build(WindowWarning())
    warning.getWindow()


if __name__ == "__main__":
    main()
