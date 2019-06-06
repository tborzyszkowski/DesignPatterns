import time, sys

def print_dishes_info(dishes):
    for idx, item in enumerate(dishes, start = 1):
        print(f"{idx}. {item}")

def print_greeting():
    print("-------------------------------------")
    print("Welcome to our mexican restaurant!")
    print("-------------------------------------")

def progress_bar(length, speed):
    for i in range(length * 10):
        time.sleep(speed)
        progress = i/100.0
        
        if isinstance(progress, int):
            progress = float(progress)
        if not isinstance(progress, float):
            progress = 0
        block = int(round(10*progress))
        text = "\r[{}]".format( "#"*block + "-"*(length-block))
        sys.stdout.write(text)
        sys.stdout.flush()
