from concrete_factory_form1 import FormFactory1
from concrete_factory_form2 import FormFactory2
from concrete_factory_form3 import FormFactory3
from concrete_factory_component1 import ComponentFactory1
from concrete_factory_component2 import ComponentFactory2
from concrete_factory_component3 import ComponentFactory3

import time

def main():
    print('\n')

    startTime = time.time()

    for i in range(100000):
        components = ComponentFactory1()
        form = FormFactory1(components)
        form.create_form()

        components = ComponentFactory2()
        form = FormFactory2(components)
        form.create_form()

        components = ComponentFactory3()
        form = FormFactory3(components)
        form.create_form()

    endTime = time.time()
    print('Total time: {}'.format(round(endTime - startTime, 2)))

if __name__ == '__main__':
    main()
