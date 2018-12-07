import functools
import logging
import time


def logged(log='trace'):
    def wrap(function):
        @functools.wraps(function)
        def wrapper(*args, **kwargs):
            logger = logging.getLogger(log)
            logger.debug("Calling function '{}' with args={} kwargs={}"
                             .format(function.__name__, args, kwargs))
            try:
                response = function(*args, **kwargs)
            except Exception as error:
                logger.debug("Function '{}' raised {} with error '{}'"
                                 .format(function.__name__,
                                         error.__class__.__name__,
                                         str(error)))
                raise error
            logger.debug("Function '{}' returned {}"
                             .format(function.__name__,
                                     response))
            return response
        return wrapper
    return wrap

def slow_down(func):
    @functools.wraps(func)
    def wrapper_slow_down(*args, **kwargs):
        time.sleep(1)
        return func(*args, **kwargs)
    return wrapper_slow_down


def debug(func):
    @functools.wraps(func)
    def wrapper_debug(*args, **kwargs):
        args_repr = [repr(a) for a in args]
        kwargs_repr = [f"{k}={v!r}" for k, v in kwargs.items()]
        signature = ", ".join(args_repr + kwargs_repr)
        print(f"Calling {func.__name__}({signature})")
        value = func(*args, **kwargs)
        print(f"{func.__name__!r} returned {value!r}")
        return value
    return wrapper_debug



def timer(func):
    @functools.wraps(func)
    def wrapper_timer(*args, **kwargs):
        start_time = time.perf_counter()
        value = func(*args, **kwargs)
        end_time = time.perf_counter()
        run_time = end_time - start_time
        print(f"Finished {func.__name__!r} in {run_time:.4f} secs")
        return value
    return wrapper_timer