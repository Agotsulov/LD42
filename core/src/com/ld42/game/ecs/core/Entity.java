package com.ld42.game.ecs.core;

import java.util.List;

public abstract class Entity extends GameObject implements Container<Component>{

    public Entity(Engine engine, String name) {
        super(engine, name);
    }

    private boolean deleteThis = false;

    public void doDelete() {
        deleteThis = false;
    }

    public void doNotDelete() {
        deleteThis = true;
    }
}
