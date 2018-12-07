from  projekt.Database import PgSQLAPI,Database,Sqlite3API,MySQLdbAPI
from projekt.Query import Select, Delete, Update


class Launcher(object):
    def __init__(self, db):
        self.conn = Database(db)

    def query(self):
        self.conn.connect()
        self.conn.show_config()
        SelectBuilder = Select()
        select = SelectBuilder.action("abc").fromm("cde").where("a=11").like("grzyb").commit()
        select.drukuj()
        DeleteBuilder = Delete()
        delete = DeleteBuilder.action("xyz").fromm("kątownia").where("b=cos").like("chomik").commit()
        self.conn.trans.addTrans(delete)
        delete.drukuj()
        UpdateBuilder = Update()
        update = UpdateBuilder.action("cos").set("a=1").fromm("kątownia").where("b=cos").like("chomik").commit()
        self.conn.trans.addTrans(update)
        update.drukuj()
        for k,v in self.conn.trans.showTrans().items():
            print("transaction number-> {} recorded object origin -> {} @ {} database".format(k, v, self.conn.db.__str__()))
        self.conn.close_conn()


if __name__=="__main__":
    sql = Launcher(Sqlite3API)
    sql.query()
    sql = Launcher(PgSQLAPI)
    sql.query()
    sql = Launcher(MySQLdbAPI)
    sql.query()



