require_relative 'shop'
require_relative 'eztBuilder'
class Main
  def main
    shop = Shop.new
    dart = shop.train(EztBuilder.new)
    shop.build
  end
end

main = Main.new
main.main
