from iseacraft import ISeaCraft
from iaircraft import IAirCraft
from aircraft import AirCraft
from seabird import SeaBird
from seabird_aircraft import SeaBirdAir


class Experiment_MakeSeaBirdFly():
    @staticmethod
    def main():
        # No adapter
        print("Experiment 1: test the aircraft engine")
        aircraft: IAirCraft = AirCraft()
        aircraft.take_off()
        if aircraft.airborne:
            print("The aircraft engine is fine, flying at", aircraft.height, "meters")

        # Classic usage of an adapter
        print("\nExperiment 2: Use the engine in the Seabird")
        seabird: IAirCraft = SeaBird()
        seabird.take_off()
        print("The Seabird took off")

        # Two-way adapter: using seacraft instructions on an IAircraft object
        # (where they are not in the IAircraft interface)
        print("\nExperiment 3: Increase the speed of the Seabird:")
        adapter: ISeaCraft = seabird
        adapter.increase_revs()
        adapter.increase_revs()
        if seabird.airborne:
            print("Seabird flying at height ", seabird.height, " meters and speed ", seabird.speed, " knots")
        print("Experiments successful; the Seabird flies!")

        # Classic usage of an adapter
        print("\nExperiment 4: Increase the speed of the Seabird")
        seabirdair: ISeaCraft = SeaBirdAir()
        seabirdair.increase_revs()
        seabirdair.increase_revs()
        seabirdair.increase_revs()
        seabirdair.increase_revs()
        seabirdair.increase_revs()
        seabirdair.increase_revs()
        seabirdair.increase_revs()
        seabirdair.increase_revs()
        if seabirdair.airborne:
            print("The Seabird took off")
            print("Seabird flying at height ", seabirdair.height, " meters and speed ", seabirdair.speed, " knots")

        # Two-way adapter: using aircraft instructions on an ISeeCraft object
        # (where they are not in the ISeeCraft interface)
        print("\nExperiment 5: Use the engine in the Seabird:")
        adapter: IAirCraft = seabirdair
        adapter.airborne = False
        adapter.speed = 0
        adapter.take_off()
        if seabirdair.airborne:
            print("Seabird flying at height ", seabirdair.height, " meters and speed ", seabirdair.speed, " knots")
        print("Experiments successful; the Seabird flies!")
