package ChainOfResponsibility;

import java.util.List;

public interface Stage {

    void setNextStage(Stage nextStage);

    void procedure(List players);
}
