from window_error_concrete_builder import WindowError
from window_info_concrete_builder import WindowInfo
from window_warning_concrete_builder import WindowWarning
from message_dicector import Message


def main():
    message = Message()

    builder = WindowError()
    message.build(builder)
    builder.window.getWindow()

    print('\n')

    builder = WindowInfo()
    message.build(builder)
    builder.window.getWindow()

    print('\n')

    builder = WindowWarning()
    message.build(builder)
    builder.window.getWindow()


if __name__ == "__main__":
    main()
