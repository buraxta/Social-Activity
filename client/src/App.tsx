import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { DatePicker } from "antd";
import Paragraph from "antd/es/typography/Paragraph";

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios
      .get("http://localhost:5000/api/activities")
      .then((response) => {
        setActivities(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, []);

  return (
    <>
      <h1>Social Activity</h1>
      <ul>
        {activities.map((activity: any) => (
          <li key={activity.id}>{activity.title}</li>
        ))}
      </ul>
      <DatePicker
        onChange={(date, dateString) =>
          console.log("date", date, "dateString", dateString)
        }
      />
      <Paragraph copyable>This is a copyable text. aasdasdasd</Paragraph>
    </>
  );
}

export default App;
