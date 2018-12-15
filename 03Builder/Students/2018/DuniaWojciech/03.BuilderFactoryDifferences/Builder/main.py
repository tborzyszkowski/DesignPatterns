from window_error_concrete_builder import WindowError
from window_info_concrete_builder import WindowInfo
from window_warning_concrete_builder import WindowWarning
from message_director import Message

import time

def main():
    message = Message()

    startTime = time.time()

    for i in range(300000):
        msg = message.build(WindowError())

    endTime = time.time()
    print('\nCzas wykonania 1:')
    print('Total time: {}'.format(round(endTime - startTime, 2)))

    # Builder lepszy niż abstrakcyjna fabryka - gdy czesto potrzebujemy lekkie modyfikacje obiektu
    startTime = time.time()
    for i in range(30000):
        msg1 = WindowError().set_size().set_message().set_button_ok().set_button_cancel()()
        msg2 = WindowError().set_type().set_size().set_message().set_button_cancel()()
        msg3 = WindowError().set_size().set_message().set_button_cancel()()
        msg4 = WindowError().set_type().set_size().set_message().set_button_ok().set_button_cancel()()
        msg5 = WindowError().set_size().set_message().set_button_ok().set_button_cancel()()
        msg6 = WindowError().set_type().set_button_cancel()()
        msg7 = WindowError().set_type().set_size().set_message().set_button_ok().set_button_cancel()()
        msg8 = WindowError().set_type().set_message().set_button_cancel()()
        msg9 = WindowError().set_type().set_size().set_message().set_button_cancel()()
        msg10 = WindowError().set_type().set_size().set_message().set_button_ok()()

    endTime = time.time()
    print('\nCzas wykonania 2:')
    print('Total time: {}'.format(round(endTime - startTime, 2)))


if __name__ == "__main__":
    main()
