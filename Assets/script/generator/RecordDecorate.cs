using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RecordDecorate<JsonType> {

    void refreshUI(JsonType record);
}
