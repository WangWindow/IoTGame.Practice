import sqlite3
import os

def get_connection_string(database):
    # 根据传入的数据库名称返回不同的连接字符串
    return f"../wwwroot/Data/{database}"

def test_query_data(database, road_id):
    connection_string = get_connection_string(database)
    results = []

    if not os.path.exists(connection_string):
        # 打印当前目录下的文件
        for file in os.listdir("../wwwroot/Data"):
            print(f"File: {file}")
        return results  # 返回空表

    try:
        conn = sqlite3.connect(connection_string)
        cursor = conn.cursor()
        cursor.execute(f"SELECT date, [{road_id}] FROM ExampleData")
        rows = cursor.fetchall()
        for row in rows:
            results.append({"Date": row[0], "Value": row[1]})
        # 打印部分读取的数据
        print(f"Sample data: {results[:5]}")
        conn.close()
    except sqlite3.Error as e:
        print(f"Database error: {e}")
        return []

    return results

# 测试函数调用
if __name__ == "__main__":
    database = "example_data.db"
    road_id = "1"
    data = test_query_data(database, road_id)
    print(data)
