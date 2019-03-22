require 'singleton'

class Client
    include Singleton

    attr_accessor :url, :port, :credentials
end

class DBClient  < Client; end
class ApiClient < Client; end

main = Client.instance
main.url         = '10.11.12.13'
main.port        = 3000
main.credentials = 'username:password'

db = DBClient.instance
db.url         = '14.15.16.17'
db.port        = 4242
db.credentials = 'username:password'

api = ApiClient.instance
api.url         = '18.19.20.21'
api.port        = 8484
api.credentials = 'username:password'

puts 'main port: ' + main.port.to_s
puts 'db port: ' + db.port.to_s
puts 'api port: ' + api.port.to_s