<?php

namespace App;

class DB
{
    private $db;
    private $obj;
    private $where = "";
    private $orderBy = "";
    private static $table;

    public function __construct()
    {
        $this->db = Database::getInstance()->db;
    }

    public static function table($table)
    {
        self::$table = $table;
        return new self;
    }

    public function where($column, $value, $operator = '=')
    {
        $this->where = " WHERE $column $operator $value";
        return $this;
    }

    public function OrderBy($column, $type)
    {
        $this->orderBy = " ORDER BY $column $type";
        return $this;
    }

    public function delete()
    {
        $sql = "DELETE FROM ".self::$table." WHERE id = $this->obj->id";
        $db = $this->db;
        $db->query($sql);
    }

    public function find($id)
    {
        $this->where = " WHERE id = $id";
        return $this;
    }

    private function query()
    {
        $sql = "SELECT * FROM ".self::$table.$this->where.$this->orderBy;
        $db = $this->db;

        $stmt = $db->query($sql);
        $result = $stmt->fetch_object();
        return $this->obj = $result;
    }

    public function get()
    {
        return $this->query();
    }
}