<?php


namespace App;


class Database
{

    private static $instance;
    public $db;

    private function __construct()
    {
        $this->db = new \mysqli(DB_HOST, DB_USER, DB_PASS, DB_NAME);
        $this->db->set_charset("utf8");

        if ($this->db->connect_errno) {
            die("Database connection failed ".$this->db->connect_errno);
        }
    }

    public static function getInstance()
    {
        if (self::$instance == null) {
            self::$instance = new Database();
        }

        return self::$instance;
    }
}
