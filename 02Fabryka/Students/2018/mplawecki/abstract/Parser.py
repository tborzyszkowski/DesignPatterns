from abc import ABCMeta, abstractmethod


class Parser(metaclass=ABCMeta):
    @abstractmethod
    def __call__(self, content):
        pass

class HTTPParser(Parser):
    def __call__(self, content):
        filenames = []
        for link in content:
            filenames.append(link.text)
        return '\n'.join(filenames)


class MQTTParser(Parser):
    def __call__(self, content):
        lines = content.split('\n')
        filenames = []
        for line in lines:
            splitted_line = line.split(None, 8)
            if len(splitted_line) == 9:
                filenames.append(splitted_line[-1])
        return '\n'.join(filenames)

class MQTTWSParser(MQTTParser):
    def __call__(self, content):
        return super().__call__(content)


class AMQPParser(Parser):
    def __call__(self,content):
        content = content.split(':')
        return content


class AMQPWSParser(AMQPParser):
    def __call__(self, content):
        return super().__call__(content)