<?php
namespace Blewandowski\Tests;

use Blewandowski\SimpleFactory\UserSimpleFactory;
use Blewandowski\SimpleFactory\Entity\TrialUser;
use Blewandowski\SimpleFactory\Entity\StandardUser;
use Blewandowski\SimpleFactory\Entity\PremiumUser;
use Blewandowski\SimpleFactory\ValueObject\Email;
use PHPUnit\Framework\TestCase;

class UserSimpleFactoryTest extends TestCase
{
    private function trialUserDataProvider()
    {
        $stdClass = new \stdClass();
        $stdClass->actual = UserSimpleFactory::create('John Cleese', 'john.cleese@gmail.com', 'trial');
        $stdClass->expected = new TrialUser('John Cleese', new Email('john.cleese@gmail.com'));
        
        return $stdClass;
    }
    
    public function test_Are_names_the_same()
    {
        $provider = $this->trialUserDataProvider();
        
        $this->assertEquals($provider->expected->getName(), $provider->actual->getName());
    }
    
    public function test_Are_email_addresses_the_same()
    {
        $provider = $this->trialUserDataProvider();
        
        $this->assertEquals($provider->expected->getEmail(), $provider->actual->getEmail());
    }
    
    public function test_Is_the_factory_creating_valid_trial_user_with_all_expected_features()
    {   
        $provider = $this->trialUserDataProvider();
               
        $this->assertEquals($provider->expected->getFeatures(), $provider->actual->getFeatures());
    }
    
    public function test_Is_the_factory_creating_valid_standard_user_with_all_expected_features()
    {
        $actual = UserSimpleFactory::create('Terry Jones', 'terry.jones@gmail.com', 'standard');
        $expected = new StandardUser('Terry Jones', new Email('terry.jones@gmail.com'));
        
        $this->assertEquals($expected->getFeatures(), $actual->getFeatures());
    }
    
    public function test_Is_the_factory_creating_valid_premium_user_with_all_expected_features()
    {
        $actual = UserSimpleFactory::create('Graham Chapman', 'graham.chapman@gmail.com', 'premium');
        $expected = new PremiumUser('Graham Chapman', new Email('graham.chapman@gmail.com'));
        
        $this->assertEquals($expected->getFeatures(), $actual->getFeatures());
    }
    
    public function test_Is_the_factory_throwing_exception_when_type_has_not_been_recognized()
    {
        $this->expectException(\BadMethodCallException::class);
        
        UserSimpleFactory::create('Neil Innes', new Email('neil.innes@gmail.com'), 'super-trooper-valuable-user');
    }
}