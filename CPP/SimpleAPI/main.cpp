#include "crow_all.h"
#include "sqlite3.h"
#include <filesystem>

void init_db() {
    sqlite3* db;
    sqlite3_open("qadb.db", &db);

    const char* create_table =
        "CREATE TABLE IF NOT EXISTS users ("
        "id INTEGER PRIMARY KEY AUTOINCREMENT,"
        "username TEXT,"
        "password TEXT"
        ");";
    sqlite3_exec(db, create_table, nullptr, nullptr, nullptr);

    const char* count_query = "SELECT COUNT(*) FROM users;";
    sqlite3_stmt* stmt;
    sqlite3_prepare_v2(db, count_query, -1, &stmt, nullptr);
    sqlite3_step(stmt);
    int count = sqlite3_column_int(stmt, 0);
    sqlite3_finalize(stmt);

    if (count == 0) {
        const char* insert_mock =
            "INSERT INTO users (username, password) VALUES "
            "('mateusz', '123'),"
            "('admin', 'qwerty'),"
            "('test', 'pass');";
        sqlite3_exec(db, insert_mock, nullptr, nullptr, nullptr);
    }

    sqlite3_close(db);
}

int main() {
    init_db(); // automatyczne tworzenie bazy + mockup danych

    crow::SimpleApp app;

    CROW_ROUTE(app, "/users")([](){
        sqlite3* db;
        sqlite3_open("qadb.db", &db);

        sqlite3_stmt* stmt;
        sqlite3_prepare_v2(db, "SELECT id, username, password FROM users", -1, &stmt, nullptr);

        std::string json = "[";

        while (sqlite3_step(stmt) == SQLITE_ROW) {
            if (json.size() > 1) json += ",";
            json += "{";
            json += "\"id\":" + std::to_string(sqlite3_column_int(stmt, 0)) + ",";
            json += "\"username\":\"" + std::string((char*)sqlite3_column_text(stmt, 1)) + "\",";
            json += "\"password\":\"" + std::string((char*)sqlite3_column_text(stmt, 2)) + "\"";
            json += "}";
        }

        json += "]";

        sqlite3_finalize(stmt);
        sqlite3_close(db);

        return crow::response(json);
    });

    app.port(18080).multithreaded().run();
}
